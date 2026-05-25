import { View } from "react-native";

import LoginForm from "../../components/auth/LoginForm";

function LoginScreen({ navigation }: any) {
  return (
    <View className="flex-1 justify-center bg-blue-950 px-6">
      
      <LoginForm navigation={navigation} />
    </View>
  );
}

export default LoginScreen;