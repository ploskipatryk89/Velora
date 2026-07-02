import Logo from "../ui/Logo";
import AuthHeader from "./AuthHeader";
import Input from "./Input";
import AuthButton from "./AuthButton";
import AuthRedirect from "./AuthRedirect";
import { useState } from "react";
import { login } from "../../api/authService";
import Spinner from "../ui/Spinner";

function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  async function handleLogin() {
    try {
      setErrorMessage("");
      setIsLoading(true);
      const response = await login({
        email,
        password,
      });

      localStorage.setItem("accessToken", response.accessToken);
    } catch (error) {
      if (error instanceof Error) {
        setErrorMessage(error.message);
      }

      console.error(error);
    } finally {
      setIsLoading(false);
    }
  }
  return (
    <div className="w-full max-w-md rounded-3xl bg-blue-950/80 p-8 border-0 md:border border-blue-500 shadow-2xl shadow-violet-900/10 backdrop-blur-md">
      <Logo />

      <AuthHeader
        title="Witaj z powrotem! 👋"
        subtitle="Zaloguj się do swojego konta"
      />

      <div className="flex flex-col gap-5 mt-8">
        <Input
          placeholder="anna@example.com"
          type="text"
          label="Adres e-mail"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <Input
          placeholder="********"
          type="password"
          label="Hasło"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />

        {errorMessage && <p className="text-sm text-red-400">{errorMessage}</p>}

        {/*instrukcja warunkowa, jesli isloading true renderuje spinner*/}
        {isLoading && <Spinner />}

        <AuthButton onClick={handleLogin}>Zaloguj się</AuthButton>

        <AuthRedirect
          text="Nie masz konta?"
          linkText="Zarejestruj się"
          to="/register"
        />
      </div>
    </div>
  );
}

export default LoginForm;
