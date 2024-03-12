#!/bin/bash

# Define variables
RESOURCE_GROUP='jeremyResourceGroup'
LOCATION='EastUS'
AKS_CLUSTER_NAME='devOpsCluster'

# Create a Resource Group if it doesn't already exist
echo "Creating Resource Group: $RESOURCE_GROUP"
az group create --name $RESOURCE_GROUP --location $LOCATION

# Create the AKS cluster with 3 nodes
echo "Creating AKS Cluster: $AKS_CLUSTER_NAME with 3 nodes"
az aks create \
  --resource-group $RESOURCE_GROUP \
  --name $AKS_CLUSTER_NAME \
  --node-count 3 \
  --generate-ssh-keys 

# Get credentials to access the cluster
echo "Getting access credentials for AKS Cluster: $AKS_CLUSTER_NAME"

az aks get-credentials --resource-group $RESOURCE_GROUP --name $AKS_CLUSTER_NAME

echo "AKS Cluster $AKS_CLUSTER_NAclear
ME setup complete. You can now access it with kubectl."
