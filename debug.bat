@echo off
dotnet build src/Skybrud.Social.Mastodon --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget