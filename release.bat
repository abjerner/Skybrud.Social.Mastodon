@echo off
dotnet build src/Skybrud.Social.Mastodon --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget