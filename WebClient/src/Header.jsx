import React from 'react'
import styled from 'styled-components'

export default function Header() {
  return (
    <StyledHeader>
        <h1>MyLogo</h1>
        <button>Auto / logout</button>
    </StyledHeader>
  )
}
const StyledHeader = styled.header`
    background-color: red;
    height: 5vh;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding:5px 20px;

    & button{
        height: 35px;
    }
`;
