//
//  UITabBarController+BarVisibility.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface UITabBarController (BarVisibility)
- (void)setTabBarVisible:(BOOL)visible animated:(BOOL)animated;
- (BOOL)tabBarIsVisible;
@end
