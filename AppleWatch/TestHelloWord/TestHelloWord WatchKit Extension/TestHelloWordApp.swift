//
//  TestHelloWordApp.swift
//  TestHelloWord WatchKit Extension
//
//  Created by 木下健一 on 2021/07/19.
//

import SwiftUI

@main
struct TestHelloWordApp: App {
    @SceneBuilder var body: some Scene {
        WindowGroup {
            NavigationView {
                ContentView()
            }
        }

        WKNotificationScene(controller: NotificationController.self, category: "myCategory")
    }
}
