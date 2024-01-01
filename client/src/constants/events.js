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
      MESSAGE_SENT: 'MessageSent'
    },
    SERVER: {
      SEND_MESSAGE: 'SendMessage',
      FRIENDSHIP_REQUEST_SENDED: 'FriendRequestSended',
      MESSAGE_RECEIVED: 'MessageReceived'
    }
  },
  GAME: {
    CLIENT: {
      PLAYER_CONNECTED: 'PlayerConnected',
      PLAYER_DISCONNECTED : 'PlayerDisconnected',
      GET_INVITE_TO_GAME : 'GetInviteToGame',
      GET_INVITE_RESPONSE : 'GetInviteResponse',
      JOINED_TO_GAME:'JoinedToGame',
      GAME_IS_READY:'GameIsReady'
    },
    SERVER: {INVITE_FRIEND_TO_GAME: 'InviteFriendToGame',
    INVITE_RESPONSE_BY_GUEST: 'InviteResponseByGuest',
    CREAETE_GAME_SESSION: 'CreateGameSession',
    JOINT_TO_GAME_SESSION : 'JoinToGameSession'}
  }
}
