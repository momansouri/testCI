#!/bin/sh

if [ "$OSTYPE" == "msys" ]
then
     unity="c:\Program Files\Unity\Hub\Editor\2017.4.8f1\Editor\Unity.exe"
else 
    unity="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
fi

echo "Start running Unity edit mode tests..."
"$unity" -batchmode \
    -nographics \
    -projectPath "$(pwd)" \
    -runTests \
    -logFile "$(pwd)/output/editmode_log.xml" \
    -testResults "$(pwd)/output/editmode_results.xml" \
    -testPlatform "editmode"
#result=$?
#if [ $result -ne 0 ]; then
 #   echo "Unity editor mode tests failed."
  #  exit $result
#fi
echo "Start building the project..."
"$unity" -batchmode \
    -nographics \
    -projectPath "$(pwd)" \
    -logFile "$(pwd)/output/build_log.xml" \
    -executeMethod BuildScript.Android \
    -quit

echo "Finished !!!"