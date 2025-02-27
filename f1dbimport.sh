sudo apt install dotnet-runtime-8.0
dotnet tool install -g sqlpackage

server="localhost"
user="sa"
password=""

sqlpackage /Action:Import /SourceFile:"/home/sausa/f1db.bacpac" /TargetServerName:$server /TargetUser:$user /TargetPassword:$password /TargetDatabaseName:f1db /TargetTrustServerCertificate:True
