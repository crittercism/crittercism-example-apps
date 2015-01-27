//
//  CRUIWebViewController.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CRUIWebViewController : UIViewController <UIWebViewDelegate>

@property (nonatomic, strong) IBOutlet UIWebView *webView;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *backButton;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *forwardButton;

- (IBAction)goBack:(id)sender;
- (IBAction)goForward:(id)sender;

@end
