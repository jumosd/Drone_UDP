using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPReceiver : MonoBehaviour
{
    public string IP = "127.0.0.1"; // ������ IP (���� �׽�Ʈ��)
    public int port = 8051; // ������ ��Ʈ
    private UdpClient udpClient;
    private IPEndPoint remoteEndPoint;
    public Vector3 targetPosition; // ����� �̵��� ��ǥ ��ġ

    void Start()
    {
        // UDP Ŭ���̾�Ʈ �ʱ�ȭ
        udpClient = new UdpClient(port);
        remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
    }

}
