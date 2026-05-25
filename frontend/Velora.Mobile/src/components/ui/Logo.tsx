import { Image, Text, View } from "react-native";

import logo from "../../assets/images/velora-logo.png"

function Logo() {
  return (
    <View className="mb-6 flex-row items-center justify-center">
      <Image
        source={logo}
        className="h-10 w-10"
        resizeMode="contain"
      />

      <Text className="ml-3 text-3xl font-bold text-white">
        Velora
      </Text>
    </View>
  );
}

export default Logo;