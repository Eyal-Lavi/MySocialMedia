import React from 'react'
import styled from 'styled-components';
import ContactsList from './contacts/ContactsList';

export default function MainData() {
  return (
    <StyledMain>
      <ContactsList />
    </StyledMain>
  )
}
const StyledMain = styled.main`
  // background-color: bisque;
  background-color: #EEEEEE;
  height: 95vh;
`;