import { useState } from 'react';
import styled from 'styled-components'


const AuthPage = () => {
    const [typeAuth , setTypeAuth] = useState();
    return(
        <AuthPageDiv>
        </AuthPageDiv>
    )
}

const AuthPageDiv = styled.div`
    background-color: blue;
    width: 1000px;
    height: 500px;
`;
export default AuthPage;