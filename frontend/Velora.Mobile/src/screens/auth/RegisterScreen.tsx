import { View } from "react-native";

import RegisterForm from "../../components/auth/RegisterForm";
function RegisterScreen({navigation} : any) {
  return (
    <View className="flex-1 justify-center bg-blue-950 px-6">
      <RegisterForm  navigation={navigation}/>
    </View>
  );
}

export default RegisterScreen;