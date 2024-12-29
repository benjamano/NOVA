#!/bin/bash

# Colors for output
GREEN="\e[32m"
RED="\e[31m"
RESET="\e[0m"

# Define output directory
OUTPUT_DIR="../../Build"

# Create the output directory if it doesn't exist
echo -e "${GREEN}Ensuring output directory exists at $OUTPUT_DIR...${RESET}"
mkdir -p "$OUTPUT_DIR" || { echo -e "${RED}Failed to create output directory: $OUTPUT_DIR${RESET}" && exit 1; }

# C# Backend
echo -e "${GREEN}Building backend...${RESET}"

# Restore and build NOVAServer
dotnet restore ../NOVAServer.csproj
if dotnet build --configuration Release ../NOVAServer.csproj; then
    echo -e "${GREEN}NOVAServer built successfully.${RESET}"
else
    echo -e "${RED}Failed to build NOVAServer.${RESET}" && exit 1
fi

# Publish NOVAServer
if dotnet publish ../NOVAServer.csproj -c Release -o "$OUTPUT_DIR"; then
    echo -e "${GREEN}NOVAServer published successfully to $OUTPUT_DIR.${RESET}"
else
    echo -e "${RED}Failed to publish NOVAServer.${RESET}"
fi

# Restore and build NOVAData
dotnet restore ../../nova.data/NOVAData.csproj
if dotnet build --configuration Release ../../nova.data/NOVAData.csproj; then
    echo -e "${GREEN}NOVAData built successfully.${RESET}"
else
    echo -e "${RED}Failed to build NOVAData.${RESET}"
fi

# Publish NOVAData
if dotnet publish ../../nova.data/NOVAData.csproj -c Release -o "$OUTPUT_DIR"; then
    echo -e "${GREEN}NOVAData published successfully to $OUTPUT_DIR.${RESET}"
else
    echo -e "${RED}Failed to publish NOVAData.${RESET}"
fi

# React Frontend
echo -e "${GREEN}Building frontend...${RESET}"

# Navigate to the frontend directory
cd ../../nova.client || { echo -e "${RED}Frontend directory not found!${RESET}" }

# Install dependencies and build
npm install
if npm run build; then
    echo -e "${GREEN}Frontend built successfully.${RESET}"
else
    echo -e "${RED}Failed to build frontend.${RESET}"
fi

# Copy frontend build to the output directory
if cp -r ./dist "$OUTPUT_DIR/wwwroot"; then
    echo -e "${GREEN}Frontend files copied successfully to $OUTPUT_DIR/wwwroot.${RESET}"
else
    echo -e "${RED}Failed to copy frontend files to $OUTPUT_DIR/wwwroot.${RESET}"
fi

echo -e "${GREEN}Build and deployment process completed successfully!${RESET}"
