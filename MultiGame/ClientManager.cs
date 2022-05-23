﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace MultiGame
{
    // 클라이언트들을 관리하는 클래스
    public class ClientManager
    {
        // 클라이언트들을 담는 배열
        // 단순 배열과 다른점은 여러개의 스레드가 접근할때 자동으로 동기화 시켜줌
        public ConcurrentDictionary<int, ClientCharacter> ClientDic { get; set; }


        public ClientManager()
        {
            ClientDic = new ConcurrentDictionary<int, ClientCharacter>();
        }

        public ClientCharacter AddClient(int key, Button character)
        {
            ClientCharacter newClientCharacter = new ClientCharacter(key, character);
            // 새로운 클라이언트를 배열에 저장
            ClientDic.TryAdd(key, newClientCharacter);

            return newClientCharacter;
        }

        public void RemoveClient(ClientCharacter clientCharacter)
        {
            ClientDic.TryRemove(clientCharacter.key, out _);
        }
    }
}