//
//  CRConsoleViewControllerTableViewController.h
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 1/16/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CRConsoleViewControllerTableViewController : UITableViewController
- (IBAction)trash:(id)sender;
- (IBAction)flyIt:(id)sender;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *flyItButton;


@end
