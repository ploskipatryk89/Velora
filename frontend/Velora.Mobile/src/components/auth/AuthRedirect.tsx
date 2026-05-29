import { Text, TouchableOpacity, View } from "react-native";

type AuthRedirectProps = {
  text: string;
  linkText: string;
  onPress?: () => void;
};

function AuthRedirect({
  text,
  linkText,
  onPress,
}: AuthRedirectProps) {
  return (
    <View className="mt-2 flex-row justify-center">
      <Text className="text-zinc-400">
        {text}
      </Text>

      <TouchableOpacity onPress={onPress}>
        <Text className="ml-2 text-violet-500">
          {linkText}
        </Text>
      </TouchableOpacity>
    </View>
  );
}

export default AuthRedirect;