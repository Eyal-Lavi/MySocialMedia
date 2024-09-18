import { createContext } from "react"

export const _defualtValue = {
    auth:{
        get : {
            username: undefined,
            password: undefined,
        },
        set : {
            username: () => {},
            password: () => {},
        }
    },
}

export const AuthContext = createContext(_defualtValue);

