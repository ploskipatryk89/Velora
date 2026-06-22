import { Text, TextInput, View } from "react-native";

type InputProps = {
  label: string;
  placeholder: string;
  value: string;
  onChangeText: (text: string) => void;
  secureTextEntry?: boolean;
};

function Input({
  label,
  placeholder,
  value,
  onChangeText,
  secureTextEntry,
}: InputProps) {
  return (
    <View className="mb-4">
      <Text className="mb-2 text-lg text-zinc-300">
        {label}
      </Text>

      <TextInput
        placeholder={placeholder}
        placeholderTextColor="#71717a"
        value={value}
        onChangeText={onChangeText}
        secureTextEntry={secureTextEntry}
        className="
        text-lg
          rounded-xl
          border
          border-blue-900
          bg-blue-950
          px-4
          py-4
          text-white
           focus:border-violet-500
                    focus:ring-2
                    focus:ring-violet-500/20
          
        "
      />
    </View>
  );
}

export default Input;