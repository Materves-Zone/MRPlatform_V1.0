using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class HideShowControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private int PointID;


	// 控制场景内物体是否可以被编辑
	public void SceneAuthor()
	{
		PointID++;
		if (PointID == 1)
		{
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = false;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = false;
			}
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = false;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = false;
			}
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = false;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = false;
			}
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = false;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = false;
			}


		}

		if (PointID == 2)
		{
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = true;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = true;
			}
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = true;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = true;
			}
			if (GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>() != null)
			{
				GameObject.Find("ExhibitionScan").GetComponent<ObjectManipulator>().enabled = true;
				GameObject.Find("ExhibitionScan").GetComponent<Renderer>().enabled = true;
			}


			PointID = 0;
		}

	}
	// Update is called once per frame
	void Update()
	{

	}
}
