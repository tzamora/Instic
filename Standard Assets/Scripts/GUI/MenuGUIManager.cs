using UnityEngine;
using System.Collections;

public class MenuGUIManager : MonoBehaviour {
	
	public int numberOfPlayers = 0;
	
	private Rect startButtonRect;
	
	private Rect playerComboRect;
	
	private GUIContent[] comboBoxList;
	
	private ComboBox comboBoxControl;// = new ComboBox();
	
	private GUIStyle listStyle = new GUIStyle();
	
	// Use this for initialization
	
	void Awake()
	{
		DontDestroyOnLoad( transform.gameObject );
	}
	
	void Start () 
	{	
		//
		//
		//
		
		comboBoxList = new GUIContent[4];
		
	    comboBoxList[0] = new GUIContent("1 PLAYER");
	    
		comboBoxList[1] = new GUIContent("2 PLAYERS");
		
		comboBoxList[2] = new GUIContent("3 PLAYERS");
		
		comboBoxList[3] = new GUIContent("4 PLAYERS");
		
		//
		// Combo box
		//
		
		listStyle.normal.textColor = Color.white; 
		
		listStyle.onHover.background = new Texture2D(2, 2);
		
		listStyle.hover.background = new Texture2D(2, 2);
		
		listStyle.padding.left = 4;
		
		listStyle.padding.right = 4;
		
		listStyle.padding.top = 4;
		
		listStyle.padding.bottom = 4;
 
		playerComboRect = new Rect (10, (Screen.height / 2) + 30 , Screen.width - 20, 20);
		
		comboBoxControl = new ComboBox(playerComboRect, comboBoxList[0], comboBoxList, "button", "box", listStyle);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		//
		// draw start game button
		//
		
		startButtonRect = new Rect (10, Screen.height / 2 , Screen.width - 20, 20);
		
		if ( GUI.Button (startButtonRect, "Start Game"))
		{
			StartButtonClick();
		}
		
		//
		// draw the number of players buttons
		//
		
		comboBoxControl.Show();
	}
	
	void StartButtonClick()
	{
		//
		// set the number of player based on the combo selection
		//
		
		numberOfPlayers = comboBoxControl.SelectedItemIndex + 1;
		
		// Application.LoadLevel ("TestSceneHitting");
	}
}
