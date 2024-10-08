import styled from "styled-components";

export default function TextButton({ children, onClick , ...props }) {
  return <StyledTextButton onClick={onClick} {...props}>{children}</StyledTextButton>;
}

const StyledTextButton = styled.button`
  background-color: transparent;
  border: none;
  font-size: 16px;
  color: #006BFF;
  cursor: pointer;
  text-decoration: underline;
  padding: 8px 16px;
  transition: color 0.3s ease, text-decoration 0.3s ease;

  &:hover {
    color: #0041a3;
    text-decoration: none;
  }

  &:focus {
    outline: none;
    box-shadow: 0 0 0 3px rgba(0, 107, 255, 0.3);
  }

  &:active {
    color: #003076;
  }
`;
