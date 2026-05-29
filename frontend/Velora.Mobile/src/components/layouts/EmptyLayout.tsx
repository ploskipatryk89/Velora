import React from "react";
import {View, SafeAreaView, StatusBar} from 'react-native'

interface EmptyLayoutProps{
    children: React.ReactNode
}

export default function EmptyLayout({children} : EmptyLayoutProps){
   return(
<View className="flex-1 bg-blue-950">
        <StatusBar barStyle={"light-content"}/>

        {children}
    </View>
   )
   
}