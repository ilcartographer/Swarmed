using UnityEngine;
using DopplerInteractive.TidyTileMapper.Utilities;

public class TidyManager : MonoBehaviour {
    
	//This is the map that we will create and subsequently modify
	BlockMap map = null;
  	
	//Where to start the map generation
	public Transform startLocation;
	
  	//Our map properties - correlate directly to the map properties in the Editor Extension
  	public Vector3 tileScale = new Vector3(1.0f,1.0f,1.0f);
  	public string mapName = "Our demonstration map";
  	public BlockMap.GrowthAxis growthAxis = BlockMap.GrowthAxis.Up;
  
  	//The dimensions of our map
  	public int mapWidth;
  	public int mapHeight;
  
  	//This is the Block that we will be using to populate our map
  	public Block blockPrefab;
  
  	void Awake(){
    
    	//Make the map, it still needs to be populated
    	map = BlockUtilities.CreateBlockMap(mapName, tileScale, 5, 5, growthAxis);
    
    	//Performance: Pooling allows blocks to be disabled/enabled instead of destroyed/created
    	AssetPool.EnablePooling();
    
    	GenerateMap();
    
  	}
  
  	void Update(){ 
  	}
  
  	void GenerateMap(){
    
    	//Let's build a map
    	for(int x = 0; x < mapWidth; x++){
      
      	for(int y = 0; y < mapHeight; y++){
        
        	GameObject o = AssetPool.Instantiate(blockPrefab.gameObject);
        	Block newBlock = o.GetComponent<Block>();
        
        	BlockUtilities.AddBlockToMap(map,newBlock,false,0,false,x,y,0,false,false);
        
      	}
      
    	}

    	BlockUtilities.RefreshMap(map,true);
    
  	}
    
	}
