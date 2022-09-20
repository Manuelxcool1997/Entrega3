using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaEjercida : MonoBehaviour
{
    private MiVector position;
   
    [SerializeField] private MiVector acceleracion;
    [SerializeField] private MiVector velocidad;
    [SerializeField] private MiVector gravedad;
    [SerializeField] private MiVector fuerzaX;
    private MiVector peso;
    private MiVector Fuerza;
    [SerializeField] private float masa = 1;
    [Range(0f, 1f)] [SerializeField] private float repelente = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float friccion = 0.9f;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        position = new MiVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.blue);
        fuerzaX.Draw(position, Color.red);

        gravedad.Draw(position, Color.black);
        fuerzaX.Draw(position, Color.white);
        Fuerza.Draw(position, Color.red);

        MiVector friccion = CalcularFuerza();
        friccion.Draw(position, Color.red);
    }

    private void FixedUpdate()
    {

        peso = gravedad * masa;
        acceleracion = new MiVector(0, 0);
        HacerFUerza(peso);
        HacerFUerza(fuerzaX);

        MiVector friccion = -repelente * peso.magnitud * velocidad.normal;
        HacerFUerza(friccion);

        HacerFUerza(CalcularFuerza());

        Move();

    }

    public void Move()
    {
        velocidad = velocidad + Time.fixedDeltaTime * acceleracion;
        position = position + Time.fixedDeltaTime * velocidad;

        position.x = Revisar(position.x, ref velocidad.x);
        position.y = Revisar(position.y, ref velocidad.y);

        transform.position = new Vector3(position.x, position.y, 0);
    }

    private float Revisar(float a, ref float velocidad)
    {
        if (Mathf.Abs(a) >= cam.orthographicSize)
        {

            velocidad *= -1;
              velocidad *= repelente;
            a = Mathf.Sign(a) * cam.orthographicSize;
        }
        return a;
    }

    private void HacerFUerza(MiVector fuerza)
    {
        Fuerza += fuerza;
        acceleracion = Fuerza / masa;
    }

    private MiVector CalcularFuerza()
    {
        float netforceNormal = Fuerza.magnitud;
        float netForceMag = gravedad.magnitud * masa;

        MiVector d = -repelente * netForceMag * velocidad.normal;
        return d;
    }
}
