import { useState } from "react";
import { Text, View } from "react-native";
import Input from "./Input";
import Logo from "../ui/Logo";
import AuthHeader from "./AuthHeader";
import AuthButton from "./AuthButton";
import AuthRedirect from "./AuthRedirect";
import Spinner from "../ui/Spinner";
import {login} from "../../api/authService"

type LoginFormProps = {
  navigation: any;
};

function LoginForm({ navigation }: LoginFormProps) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);


  async function handleLogin() {
    
    try{
      setErrorMessage('')
      setIsLoading(true)

      const response = await login({
        email,
        password
      })

     
    } catch (error){
      if (error instanceof Error){
        setErrorMessage(error.message)
      }
    } finally{
      setIsLoading(false)
    }
  }


  return (
    <View
      className="
        w-full
        
        
      "
    >
      <Logo />

      <AuthHeader
        title="Witaj z powrotem! 👋"
        subtitle="Zaloguj się do swojego konta"
      />

      <View className="mt-8">
        <Input
          placeholder="anna@example.com"
          label="Adres e-mail"
          value={email}
          onChangeText={setEmail}
        />

        <Input
          placeholder="********"
          label="Hasło"
          value={password}
          onChangeText={setPassword}
          secureTextEntry
        />

        {errorMessage ? (
          <Text className="mb-4 text-sm text-red-400">
            {errorMessage}
          </Text>
        ) : null}

        {isLoading ? <Spinner /> : null}

        <AuthButton onPress={handleLogin}>
          Zaloguj się
        </AuthButton>

        <AuthRedirect
          text="Nie masz konta?"
          linkText="Zarejestruj się"
        onPress={() => navigation.navigate("Register")}
        />
      </View>
    </View>
  );
}

export default LoginForm;