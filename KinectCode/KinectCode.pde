import SimpleOpenNI.*;
import processing.opengl.*; 
import papaya.*;
 
SimpleOpenNI  context;
color[]    userClr = new color[]{    color(255,0,0),
                                     color(0,255,0),
                                     color(0,0,255),
                                     color(255,255,0),
                                     color(255,0,255),
                                     color(0,255,255)
                                   };
PFont f;
int frameNo = 0;

/*
Current experimental procedure:
1. Run the program. Get into calibration pose. 
2. Press any key to start calibration which runs for 5 seconds.
3. After 5 seconds, move normally.
*/

void setup()
{
  // instantiate a new context
  context = new SimpleOpenNI(this);
 
  // enable depthMap generation 
  context.enableDepth();
 
  // enable skeleton generation for all joints
  context.enableUser();
 
  stroke(0,0,255);
  strokeWeight(3);
  smooth();
  frame.setResizable(true);
  f = createFont("Arial",16,true);
  
  // create a window the size of the depth information
  size(2*context.depthWidth() + 300, context.depthHeight());
 
}
 
void draw()
{
  // update the camera
  context.update();
  background(0,0,0);
  

  //Draw rgb image
  //image(context.rgbImage(), 2*context.depthWidth() + 10,0, context.rgbWidth(), context.rgbWidth());
 
 
  int[] userList = context.getUsers();
  for(int i=0;i<userList.length;i++)
  {
     
    // check if the skeleton is being tracked
    if(context.isTrackingSkeleton(userList[i]))
    {
      println("Tracking");
      stroke(userClr[ (userList[i] - 1) % userClr.length ] );
      
      drawSkeleton(userList[i]);  // draw the skeleton
      writeCoordinates(userList[i]);
    }
    
  }
  
  // draw depth image on the right of skeleton
  image(context.depthImage(),context.depthWidth() + 5,0, context.depthWidth(), context.depthHeight());
  
 if(frameNo > 150){
   exit();
 }
   
}


void writeCoordinates(int userId)
{
   
  PVector[] posVectors = new PVector[17];  //Data to be dumped
  PVector[] projectivePosVectors = new PVector[17];   //Use these coordinates for plotting in MATLAB
  
  for(int i = 0; i < posVectors.length; i++) {
    posVectors[i] = new PVector();
    projectivePosVectors[i] = new PVector();
  }

  String[] jointLabels ={ "SKEL_HEAD",
                          "SKEL_NECK",
                          "SKEL_TORSO",
                          "SKEL_LEFT_SHOULDER",
                          "SKEL_LEFT_ELBOW",
                          "SKEL_LEFT_HAND",
                          "SKEL_LEFT_FINGERTIP",
                          "SKEL_RIGHT_SHOULDER",
                          "SKEL_RIGHT_ELBOW",
                          "SKEL_RIGHT_HAND",
                          "SKEL_RIGHT_FINGERTIP",
                          "SKEL_LEFT_HIP",
                          "SKEL_LEFT_KNEE",
                          "SKEL_LEFT_FOOT",
                          "SKEL_RIGHT_HIP",
                          "SKEL_RIGHT_KNEE",
                          "SKEL_RIGHT_FOOT"
                        };
  
  int[] jointNames =  { SimpleOpenNI.SKEL_HEAD,
                  SimpleOpenNI.SKEL_NECK,
                  SimpleOpenNI.SKEL_TORSO,
                  SimpleOpenNI.SKEL_LEFT_SHOULDER,
                  SimpleOpenNI.SKEL_LEFT_ELBOW,
                  SimpleOpenNI.SKEL_LEFT_HAND,
                  SimpleOpenNI.SKEL_LEFT_FINGERTIP,
                  SimpleOpenNI.SKEL_RIGHT_SHOULDER,
                  SimpleOpenNI.SKEL_RIGHT_ELBOW,
                  SimpleOpenNI.SKEL_RIGHT_HAND,
                  SimpleOpenNI.SKEL_RIGHT_FINGERTIP,
                  SimpleOpenNI.SKEL_LEFT_HIP,
                  SimpleOpenNI.SKEL_LEFT_KNEE,
                  SimpleOpenNI.SKEL_LEFT_FOOT,
                  SimpleOpenNI.SKEL_RIGHT_HIP,
                  SimpleOpenNI.SKEL_RIGHT_KNEE,
                  SimpleOpenNI.SKEL_RIGHT_FOOT 
                };

  Table coordinateTable = new Table();
  Table coordinate3DTable = new Table(); 
  
  coordinateTable.addColumn("Joint");
  coordinateTable.addColumn("X");
  coordinateTable.addColumn("Y");
  
  coordinate3DTable.addColumn("Joint");
  coordinate3DTable.addColumn("X");
  coordinate3DTable.addColumn("Y");
  coordinate3DTable.addColumn("Z");

  for (int i = 0; i < posVectors.length; i++) {
    
    context.getJointPositionSkeleton(userId, jointNames[i], posVectors[i]);
    context.convertRealWorldToProjective(posVectors[i], projectivePosVectors[i]);
    
    TableRow newRow = coordinateTable.addRow();
    newRow.setString("Joint", jointLabels[i]);
    newRow.setFloat("X", projectivePosVectors[i].x); 
    newRow.setFloat("Y", projectivePosVectors[i].y);
    
    TableRow new3DRow = coordinate3DTable.addRow();
    new3DRow.setString("Joint", jointLabels[i]);
    new3DRow.setFloat("X", posVectors[i].x); 
    new3DRow.setFloat("Y", posVectors[i].y);
    new3DRow.setFloat("Z", posVectors[i].z);

    //println("(" + (int)(posVectors[i].x/10) + "," + (int)(posVectors[i].y/10) + "," + (int)(posVectors[i].z/10) + ")");
    
  }
  
   frameNo += 1;
   
   println("Here");
   String fileName = "data/2D/frame" + frameNo + ".csv";
   String fileName3D = "data/3D/frame" + frameNo + "_3d.csv";

   saveTable(coordinateTable, fileName);
   saveTable(coordinate3DTable, fileName3D);  
   
   if(frameNo%4 == 0)
     saveFrame("video/frame-" + frameNo + ".png");
        
}

/*
List of tracked joints:
"SKEL_HEAD", 0
"SKEL_NECK", 1
"SKEL_TORSO", 2
"SKEL_LEFT_SHOULDER", 3
"SKEL_LEFT_ELBOW", 4
"SKEL_LEFT_HAND", 5
"SKEL_LEFT_FINGERTIP", 6
"SKEL_RIGHT_SHOULDER", 7
"SKEL_RIGHT_ELBOW", 8
"SKEL_RIGHT_HAND", 9
"SKEL_RIGHT_FINGERTIP", 10
"SKEL_LEFT_HIP", 11
"SKEL_LEFT_KNEE", 12
"SKEL_LEFT_FOOT", 13
"SKEL_RIGHT_HIP", 14
"SKEL_RIGHT_KNEE", 15
"SKEL_RIGHT_FOOT" 16
*/

void drawSkeleton(int userId)
{
// draw the skeleton with the selected joints
 context.drawLimb(userId, SimpleOpenNI.SKEL_HEAD, SimpleOpenNI.SKEL_NECK);

  context.drawLimb(userId, SimpleOpenNI.SKEL_NECK, SimpleOpenNI.SKEL_LEFT_SHOULDER);
  context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_SHOULDER, SimpleOpenNI.SKEL_LEFT_ELBOW);
  context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_ELBOW, SimpleOpenNI.SKEL_LEFT_HAND);

  context.drawLimb(userId, SimpleOpenNI.SKEL_NECK, SimpleOpenNI.SKEL_RIGHT_SHOULDER);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_SHOULDER, SimpleOpenNI.SKEL_RIGHT_ELBOW);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_ELBOW, SimpleOpenNI.SKEL_RIGHT_HAND);

  //context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_SHOULDER, SimpleOpenNI.SKEL_TORSO);
  //context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_SHOULDER, SimpleOpenNI.SKEL_TORSO);
  
  context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_SHOULDER, SimpleOpenNI.SKEL_LEFT_HIP);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_SHOULDER, SimpleOpenNI.SKEL_RIGHT_HIP);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_HIP, SimpleOpenNI.SKEL_LEFT_HIP);

  //context.drawLimb(userId, SimpleOpenNI.SKEL_TORSO, SimpleOpenNI.SKEL_LEFT_HIP);
  context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_HIP, SimpleOpenNI.SKEL_LEFT_KNEE);
  context.drawLimb(userId, SimpleOpenNI.SKEL_LEFT_KNEE, SimpleOpenNI.SKEL_LEFT_FOOT);

  //context.drawLimb(userId, SimpleOpenNI.SKEL_TORSO, SimpleOpenNI.SKEL_RIGHT_HIP);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_HIP, SimpleOpenNI.SKEL_RIGHT_KNEE);
  context.drawLimb(userId, SimpleOpenNI.SKEL_RIGHT_KNEE, SimpleOpenNI.SKEL_RIGHT_FOOT);  
}
 
// Event-based Methods
 
// when a person ('user') enters the field of view
void onNewUser(int userId)
{
  println("New User Detected - userId: " + userId);
 
 // start pose detection
  //context.startPoseDetection("Psi",userId);
}
 
// when a person ('user') leaves the field of view 
void onLostUser(int userId)
{
  println("User Lost - userId: " + userId);
}
 
// when a user begins a pose
void onStartPose(String pose,int userId)
{
  println("Start of Pose Detected  - userId: " + userId + ", pose: " + pose);
 
  // stop pose detection
  //context.stopPoseDetection(userId); 
 
  // start attempting to calibrate the skeleton
  //context.requestCalibrationSkeleton(userId, true); 
}
 
// when calibration begins
void onStartCalibration(int userId)
{
  println("Beginning Calibration - userId: " + userId);
}
 
// when calibaration ends - successfully or unsucessfully 
void onEndCalibration(int userId, boolean successfull)
{
  println("Calibration of userId: " + userId + ", successfull: " + successfull);
 
  if (successfull) 
  { 
    println("  User calibrated !!!");
 
    // begin skeleton tracking
    context.startTrackingSkeleton(userId); 
  } 
  else 
  { 
    println("  Failed to calibrate user !!!");
 
    // Start pose detection
    //context.startPoseDetection("Psi",userId);
  }
}

void onNewUser(SimpleOpenNI curContext, int userId)
{
  println("onNewUser - userId: " + userId);
  println("\tstart tracking skeleton");
  
  curContext.startTrackingSkeleton(userId);
}

void onLostUser(SimpleOpenNI curContext, int userId)
{
  println("onLostUser - userId: " + userId);
}

void onVisibleUser(SimpleOpenNI curContext, int userId)
{
  //println("onVisibleUser - userId: " + userId);
}

