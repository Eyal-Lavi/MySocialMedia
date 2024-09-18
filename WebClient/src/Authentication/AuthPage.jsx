import { useContext } from "react";
import { AuthContext } from "../store/authentication-info-context";
import styled from 'styled-components'


const AuthPage = () => {
    const authCtx = useContext(AuthContext);
    return(
        <FatherDiv>
            <div>
                <input type="text" />
                
            </div>
        </FatherDiv>
    )
}

const FatherDiv = styled.div`
    background-color: red;
    width: 100vw;
    height: 100vh;
`;

export default AuthPage;