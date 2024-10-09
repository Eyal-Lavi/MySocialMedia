import styled from "styled-components"

export default function CloseButton({children , style , ...props}){
    return <StyledCloseButton {...props} style={style}>
        {children}
    </StyledCloseButton>
}

const StyledCloseButton = styled.button`
  & {
    background-color: transparent;
    border: 2px solid #ececec;
    border-radius: 50%;
    color: #555555;
    font-size: 24px;
    font-weight: bold;
    width: 40px;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease, box-shadow 0.3s ease;
  }

  &:hover {
    background-color: #555555;
    color: white;
    box-shadow: 0 0 8px rgba(85, 85, 85, 0.6);
  }

  &:active {
    background-color: #333333;
    color: white;
    box-shadow: 0 0 6px rgba(51, 51, 51, 0.6);
  }

  &:focus {
    outline: none;
    // box-shadow: 0 0 0 3px rgba(85, 85, 85, 0.5);
  }
`;
