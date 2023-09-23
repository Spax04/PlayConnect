// import io from 'socket.io-client'
// import { Children, createContext, useContext, useEffect, useReducer } from 'react'
// import EVENTS from '../utils/events';

// const SocketReducer = (state, action) => {
//     switch (action.type) {
//         case "SET_USERNAME":
//             return { ...state, username: action.payload };
//         case "SET_ROOM_ID":
//             return { ...state, roomId: action.payload };
//         case "SET_ROOMS":
//             return { ...state, rooms: { ...action.payload } };
//         case "SET_NEW_MESSAGE":
//             return { ...state, messages: [...state.messages, action.payload] };
//         case "CLEARE_MESSAGES":
//             return { ...state, messages: [] };
//         default:
//             return { ...state };
//     }
// }
// const socket = io("http://localhost:5000");

// let initialState = {
//     socket: socket,
//     username: '',
//     roomId: '',
//     rooms: {},
//     messages: []

// }

// const SocketContext = createContext();

// function SocketProvider(props) {

//     useEffect(()=>{
//         window.onfocus = () =>{document.title = "Chat App"}
//     },[])
//     const [state, dispatch] = useReducer(SocketReducer, initialState)

//     socket.on(EVENTS.SERVER.ROOMS, (value) => {
//         dispatch({ type: "SET_ROOMS", payload: value })
//     })

//     socket.on(EVENTS.SERVER.JOINED_ROOM, (value) => {
//         dispatch({ type: "SET_ROOM_ID", payload: value })
//         dispatch({ type: "CLEARE_MESSAGES" })
//     })

//     useEffect(() => {
//         socket.on(EVENTS.SERVER.ROOM_MESSAGE, ({ message, username, time }) => {
//             if(!document.hasFocus()){
//                 document.title = "✉ New Message"
//             }
//             dispatch({ type: "SET_NEW_MESSAGE", payload: { message, username, time } })
//         })
//     }, [])

//     return <SocketContext.Provider value={{ state, dispatch }} {...props} />
// }

// export const useSockets = () => useContext(SocketContext);

// export default SocketProvider