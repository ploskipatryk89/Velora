import './global.css';
import React from 'react';
import { StatusBar } from 'expo-status-bar'; // Jeśli używasz Expo
// import { StatusBar } from 'react-native'; // <--- Użyj tego importu, jeśli to czysty React Native (bez Expo)
import AppNavigator from './src/navigation/AppNavigator';

export default function App() {
  return (
    <>
      <StatusBar style="light" backgroundColor="transparent" translucent />
      <AppNavigator />
    </>
  );
}
