//7/10
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    //���̕����������񋓌^�i�㉺�A���E�A�~�j
    [SerializeField] public Direction roadDirection;
    //���̃I�u�W�F�N�g�ւ̎Q��
    [SerializeField] public RoadObject nextRoad;

    public enum Direction
    {
        UpDown,  //�㉺
        LeftRight,�@�@//���E
        Circular,�@�@//�~
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
