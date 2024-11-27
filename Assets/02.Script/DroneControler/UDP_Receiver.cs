using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPReceiver : MonoBehaviour
{
    public string IP = "127.0.0.1"; // 수신할 IP 주소 (기본 테스트용)
    public int port = 8051; // 수신할 포트
    private UdpClient udpClient;
    private IPEndPoint remoteEndPoint;
    public Vector3 targetPosition; // 수신한 데이터를 기반으로 이동할 목표 위치

    void Start()
    {
        // UDP 클라이언트 초기화
        udpClient = new UdpClient(port);
        remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
    }
}
