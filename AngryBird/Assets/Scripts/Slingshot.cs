using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public static Slingshot Instance { get; private set; }

    private LineRenderer LeftLineRenderer;
    private LineRenderer RightLineRenderer;

    private Transform LeftPoint;
    private Transform RightPoint;
    private Transform Centerpoint;
    private Transform birdTransform;

    private void Awake()
    {
        Instance = this;
    }

    private bool isDrawing;//Ƥ���Ƿ���Ҫ���ƣ�
    private float normalized;

    // Start is called before the first frame update


    void Start()
    {   //�ú�������Ƥ���λ�ã��õ�Ƥ�����
        LeftLineRenderer = transform.Find("LeftLineRenderer").GetComponent<LineRenderer>();
        RightLineRenderer = transform.Find("RightLineRenderer").GetComponent<LineRenderer>();

        LeftPoint = transform.Find("LeftPoint");
        RightPoint = transform.Find("RightPoint");
        Centerpoint = transform.Find("CenterPoint");

        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }

    //�ú����ж��Ƿ���Ҫ����Ƥ��

    public void StartDraw(Transform birdTransform)
    {
        isDrawing = true;
        this.birdTransform = birdTransform;//ÿ�λ�ȡС��λ��
        ShowLine();
    }

    public void EndDraw()
    {
        isDrawing = false;
        HideLine();
    }

    public void Draw()
    {
        Vector3 birdPosition = birdTransform.position;//��ȡ��λ�ã�ʹ������С���������

        birdPosition = (birdPosition - Centerpoint.position).normalized * 1.0f + birdPosition;


        LeftLineRenderer.SetPosition(0, birdPosition);
        LeftLineRenderer.SetPosition(1, LeftPoint.position);

        RightLineRenderer.SetPosition(0, birdPosition);
        RightLineRenderer.SetPosition(1, RightPoint.position);

    }

    public  Vector3 getCenterPositon()//��ȡcenterλ�ã����ڿ��Ƶ�����Χ
    {
        return Centerpoint.transform.position;
    }
    public void HideLine()//��û�е��С��ʱ�����߶�
    {
        RightLineRenderer.enabled = false;
        LeftLineRenderer.enabled = false;
    }

    public void ShowLine()
    {
        RightLineRenderer.enabled = true;
        LeftLineRenderer.enabled = true;
    }
}
