import { useState } from "react";
import { Text, View } from "react-native";

import Logo from "../ui/Logo";
import AuthHeader from "./AuthHeader";
import Input from "./Input";
import AuthButton from "./AuthButton";
import AuthRedirect from "./AuthRedirect";
import {register} from "../../api/authService"


type RegisterFormProps = {
  navigation: any;
};
function RegisterForm({navigation} : RegisterFormProps) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");

  const [email, setEmail] = useState("");

  const [password, setPassword] = useState("");

  const [repeatedPassword, setRepeatedPassword] =
    useState("");

  return (
    <View
      className="
        
        

      "
    >
      <Logo />

      <AuthHeader
        title="Utwórz swoje konto 👋"
        subtitle="Zacznij zarządzać swoimi finansami"
      />

      <View className="mt-8 gap-5">

        <View className="flex-row gap-4">
          <View className="flex-1">
            <Input
              placeholder="Joanna"
              label="Imię"
              value={firstName}
              onChangeText={setFirstName}
            />
          </View>

          <View className="flex-1">
            <Input
              placeholder="Kowalska"
              label="Nazwisko"
              value={lastName}
              onChangeText={setLastName}
            />
          </View>
        </View>

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

        <Input
          placeholder="********"
          label="Powtórz hasło"
          value={repeatedPassword}
          onChangeText={setRepeatedPassword}
          secureTextEntry
        />

        <AuthButton>
          Zarejestruj się
        </AuthButton>

        <AuthRedirect
          text="Masz już konto?"
          linkText="Zaloguj się"
         onPress={() => navigation.navigate("Login")}
        />
      </View>
    </View>
  );
}

export default RegisterForm;