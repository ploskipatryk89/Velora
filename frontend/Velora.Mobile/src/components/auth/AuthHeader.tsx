import { Text, View } from "react-native";

type AuthHeaderProps = {
  title: string;
  subtitle: string;
};

function AuthHeader({ title, subtitle }: AuthHeaderProps) {
  return (
    <View className="items-center">
      <Text className="text-3xl font-bold text-white">
        {title}
      </Text>

      <Text className="mt-1 text-zinc-500">
        {subtitle}
      </Text>
    </View>
  );
}

export default AuthHeader;