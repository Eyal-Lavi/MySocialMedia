import { createContext } from "react"

const _defualtValue = {
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

{/*'_defualtValue' only for easy using , let you know what you have on the context*/}
export const AuthContext = createContext(_defualtValue);


