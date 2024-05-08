#!/bin/bash

echo "Start Build for appsflyer-unity-adrevenue-generic-connector.unitypackage"

DEPLOY_PATH=outputs
UNITY_PATH="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
PACKAGE_NAME="appsflyer-unity-adrevenue-generic-connector-6.14.3.unitypackage"
mkdir -p $DEPLOY_PATH

echo "move dependency manager to root"
mv external-dependency-manager-1.2.177.unitypackage ..

# Build the .unitypackage
/Applications/Unity/Hub/Editor/2020.3.41f1/Unity.app/Contents/MacOS/Unity \
-gvh_disable \
-batchmode \
-importPackage external-dependency-manager-1.2.177.unitypackage \
-nographics \
-logFile create_unity_core.log \
-projectPath $PWD/../ \
-exportPackage \
Assets \
$PWD/$DEPLOY_PATH/$PACKAGE_NAME \
-quit \
&& echo "package exported successfully to outputs/appsflyer-unity-adrevenue-generic-connector-6.14.3.unitypackage" \
|| echo "Failed to export package. See create_unity_core.log for more info."

echo "moving dependency manager back to deploy"
mv ../external-dependency-manager-1.2.177.unitypackage .

if [ "$1" == "-p" ]; then
echo "removing ./Library"
rm -rf ../Library
echo "removing ./Logs"
rm -rf ../Logs
echo "removing ./Packages"
rm -rf ../Packages
echo "removing ./ProjectSettings"
rm -rf ../ProjectSettings
echo "removing ./deploy/create_unity_core.log"
rm ./create_unity_core.log
echo "Moving  $DEPLOY_PATH/$PACKAGE_NAME to root"
mv ./outputs/$PACKAGE_NAME ..
echo "removing ./deploy/outputs"
rm -rf ./outputs
echo "removing ./Assets extra files"
rm -rf ../Assets/ExternalDependencyManager
rm -rf ../Assets/PlayServicesResolver
rm ../Assets/ExternalDependencyManager.meta
rm ../Assets/PlayServicesResolver.meta
else
echo "dev mode. No files removed. Run with -p flag for production build."
fi
