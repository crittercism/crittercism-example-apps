//
//  CRUIWebViewController.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRUIWebViewController.h"
#import "UITabBarController+BarVisibility.h"

@interface CRUIWebViewController ()
@property (nonatomic, assign) CGRect savedTabBarFrame;
@end

@implementation CRUIWebViewController

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];

    [[self tabBarController] setTabBarVisible:NO animated:NO];

    NSURL *google = [NSURL URLWithString:@"http://www.google.com"];
    NSURLRequest *request = [NSURLRequest requestWithURL:google];
    [_webView loadRequest:request];
    [_webView setDelegate:self];
}


- (void)viewWillDisappear:(BOOL)animated {
    [[self tabBarController] setTabBarVisible:YES animated:NO];
    [super viewWillDisappear:animated];
}

- (void)viewDidLoad {
    [super viewDidLoad];

    // Hack to make a "play" button look like a "back" button.
    // iOS oddly doesn't have a "back" toolbar button.
    // As for the even hackier way of rotating a UIButton, credit goes to
    // this post:
    // http://stackoverflow.com/questions/3863929/transform-rotate-a-uibarbuttonitem
    UIView *backButton = [_backButton valueForKey:@"view"];
    backButton.transform = CGAffineTransformMakeRotation(M_PI);
    [self updateNavigationButtons];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (void)webViewDidFinishLoad:(UIWebView *)webView {
    [self updateNavigationButtons];
}

- (IBAction)goForward:(id)sender {
    if ([_webView canGoForward]) {
        [_webView goForward];
    }
}

- (IBAction)goBack:(id)sender {
    if ([_webView canGoBack]) {
        [_webView goBack];
    }
}

- (void)updateNavigationButtons {
    [_backButton setEnabled:_webView.canGoBack];
    [_forwardButton setEnabled:_webView.canGoForward];
}

- (UITabBarController *)tabBarController {
    return (UITabBarController *) self.parentViewController.parentViewController;
}

@end
