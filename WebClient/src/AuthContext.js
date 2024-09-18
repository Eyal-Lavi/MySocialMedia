import { createContext, useState, useContext } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false); // מצב התחברות

  const login = () => {
    setIsAuthenticated(true);  // עדכון מצב התחברות בעת התחברות
  };

  const logout = () => {
    setIsAuthenticated(false);  // עדכון מצב התחברות בעת התנתקות
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
