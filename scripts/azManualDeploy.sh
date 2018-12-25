#!/bin/bash
# Replace the following URL with a public GitHub repo URL
gitrepo=https://github.com/PontusIvarsson/Softinsight
webappname=Softinsight2
myResourceGroup=SoftinsightResourceGroup

az webapp deployment source sync --name $webappname --resource-group $myResourceGroup