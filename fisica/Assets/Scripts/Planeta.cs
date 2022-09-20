using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    
    private MiVector posicion;
    private MiVector desplazamiento;
    [SerializeField] private MiVector acceleracion;
    [SerializeField] private MiVector velocidad;
    [Range(0, 1)] [SerializeField] private float fuerzaRepelente = 1.1f;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        posicion = new MiVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        desplazamiento.Draw(Color.red);
        desplazamiento.Draw(Color.green);

        Move();
        Cambiar();
    }

    public void Move()
    {
        velocidad = velocidad + acceleracion * Time.deltaTime;
        posicion = posicion + velocidad * Time.deltaTime;

        if(Mathf.Abs(transform.position.x) > camera.orthographicSize)
        {
            velocidad *= -1;
            posicion.x = Mathf.Sign(posicion.x) * camera.orthographicSize;
            velocidad *= fuerzaRepelente;
        }
        if (Mathf.Abs(transform.position.y) > camera.orthographicSize)
        {
            velocidad.y *= -1;
            posicion.y = Mathf.Sign(posicion.y) * camera.orthographicSize;
            velocidad *= fuerzaRepelente;
        }
        transform.position = new Vector3(posicion.x, posicion.y);
    }

    public void Cambiar()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(acceleracion.x > 0)
            {
                acceleracion.y = acceleracion.x;
                acceleracion.x = 0;
                velocidad.x = 0;
            }
            else if (acceleracion.x < 0)
            {
                acceleracion.y = acceleracion.x;
                acceleracion.x = 0;
                velocidad.x = 0;
            }
            else if (acceleracion.y < 0)
            {
                acceleracion.x -= acceleracion.y;
                acceleracion.y = 0;
                velocidad.y = 0;
            }
            else if (acceleracion.y > 0)
            {
                acceleracion.x -= acceleracion.y;
                acceleracion.y = 0;
                velocidad.y = 0;
            }
           
        }
    }
}
