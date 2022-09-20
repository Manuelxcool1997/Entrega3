using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgugeroNegro : MonoBehaviour
{
    private MiVector position;
    [SerializeField] private MiVector acceleracion;
    [SerializeField] private MiVector velocidad;
    [Range(0, 1)] [SerializeField] private float fuerzaRepelente = 1.1f;


    [SerializeField] private Camera cam;

    [SerializeField] private Transform agugeroNegro;
    private MiVector agugeronegroV;
    private MiVector posicionV;

    // Start is called before the first frame update
    void Start()
    {
        position = new MiVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        acceleracion.Draw(position, Color.blue);

        MiVector positionT = new MiVector(transform.position.x, transform.position.y);
        MiVector blackholet = new MiVector(agugeroNegro.position.x, agugeroNegro.position.y);

        acceleracion = blackholet - positionT;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        velocidad = velocidad + acceleracion * Time.fixedDeltaTime;
        position = position + velocidad * Time.fixedDeltaTime;

        transform.position = new Vector3(position.x, position.y);
    }
}
