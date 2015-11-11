/*
 * Copyright 2015 Crittercism
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


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
