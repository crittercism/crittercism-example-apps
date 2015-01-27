//
//  UITabBarController+BarVisibility.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "UITabBarController+BarVisibility.h"

@implementation UITabBarController (BarVisibility)

// Credit: http://stackoverflow.com/questions/20935228/how-to-hide-tab-bar-with-animation-in-ios
- (void)setTabBarVisible:(BOOL)visible animated:(BOOL)animated {
    // bail if the current state matches the desired state
    if ([self tabBarIsVisible] == visible)
        return;

    // get a frame calculation ready
    CGRect frame = self.tabBar.frame;
    CGFloat height = frame.size.height;
    CGFloat offsetY = (visible)? -height : height;

    // zero duration means no animation
    CGFloat duration = (animated)? 0.3 : 0.0;

    [UIView animateWithDuration:duration animations:^{
        self.tabBar.frame = CGRectOffset(frame, 0, offsetY);
    }];
}

- (BOOL)tabBarIsVisible {
    return self.tabBar.frame.origin.y < CGRectGetMaxY(self.view.frame);
}

@end
