// eslint-disable-next-line import/no-anonymous-default-export
export default {
  CHAT: {
    CLIENT: {
      SEND_MESSAGE: 'SendMessage',
      CHATTER_CONNECTED: 'ChatterConnected',
      CHATTER_DISCONNECTED: 'ChatterDisconnect',
      ON_GET_FRIENDS: 'onGetFriends',
      RECEIVE_MESSAGE: 'ReceiveMessage',
      ON_MESSAGE_RECEIVED: 'OnMessageReceived',
      MESSAGE_SENT: 'MessageSent',
      CONNECTED_TO_GROUP_CHAT: 'ConnectedToGroupChat',
      GROUP_MESSAGE_RECEIVED:'GroupMessageReceived'
    },
    SERVER: {
      SEND_MESSAGE: 'SendMessage',
      FRIENDSHIP_REQUEST_SENDED: 'FriendRequestSended',
      MESSAGE_RECEIVED: 'MessageReceived',
      CONNECT_TO_CHAT_GROUP: 'ConnectToChatGroup',
      SEND_GROUP_MESSAGE: 'SendGroupMessage'
    }
  },
  GAME: {
    CLIENT: {
      PLAYER_CONNECTED: 'PlayerConnected',
      PLAYER_DISCONNECTED: 'PlayerDisconnected',
      GET_INVITE_TO_GAME: 'GetInviteToGame',
      GET_REFUSAL_RESPONSE: 'GetRefusalResponse',
      JOINED_TO_GAME: 'JoinedToGame',
      READY_TO_GAME: 'ReadyToGame',
      NEW_GAME_MOVE: 'NewGameMove',
      RECONNECT_TO_GAME: 'ReconnectToGame',
      OPPONENT_DISCONECTED: 'OpponentDisconnected',
      RECONNECT_HANDLER: 'ReconnectHandler',
      OPPONENT_RECONNECTED: 'OpponentReconected'
    },
    SERVER: {
      INVITE_FRIEND_TO_GAME: 'InviteFriendToGame',
      INVITE_RESPONSE_BY_GUEST: 'InviteResponseByGuest',
      CREAETE_GAME_SESSION: 'CreateGameSession',
      JOINT_TO_GAME_SESSION: 'JoinToGameSession',
      MAKE_GAME_MOVE: 'MakeGameMove',
      GAME_OVER: 'GameOver',
      OPPONENT_RECONNECT: 'OpponentReconnect',
      RECONNECT_COMPLITED: 'ReconnectComplited'
    }
  }
}
