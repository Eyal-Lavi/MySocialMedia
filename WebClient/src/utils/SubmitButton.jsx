import styled from "styled-components";

export default function SubmitButton({children , ...props }) {
  return (
    <StyledButton {...props} className="bebas-font">
      {children}
    </StyledButton>
  );
}

const StyledButton = styled.button`
  & {
    background-color: #006BFF;
    border: none;
    border-radius: 24px;
    font-size: 18px;
    padding: 12px 20px;
    color: white;
    margin: 10px 5px;
    cursor: pointer;
    transition: background-color 0.3s ease, box-shadow 0.3s ease;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  }

  &:hover {
    background-color: #0056cc;
    box-shadow: 0 6px 10px rgba(0, 0, 0, 0.2);
  }

  &:active {
    background-color: #0041a3;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.2);
  }

  &:focus {
    outline: none;
    box-shadow: 0 0 0 3px rgba(0, 107, 255, 0.5); 
  }
`;
