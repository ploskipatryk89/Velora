import { Pressable, Text } from "react-native";

type ButtonProps = {
  children: React.ReactNode;
  onPress?: () => void;
};

function AuthButton({ children, onPress }: ButtonProps) {
  return (
    <Pressable
      onPress={onPress}
      className="mt-2 rounded-xl bg-violet-600 py-3 text-lg"
    >
      <Text className="text-center font-semibold text-white text-lg">
        {children}
      </Text>
    </Pressable>
  );
}

export default AuthButton;