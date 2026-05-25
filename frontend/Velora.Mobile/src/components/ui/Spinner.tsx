import { ActivityIndicator, View } from "react-native";

function Spinner() {
  return (
    <View className="items-center justify-center">
      <ActivityIndicator
        size="large"
        color="#60a5fa"
      />
    </View>
  );
}

export default Spinner;