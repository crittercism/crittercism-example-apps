//
//  NetworkViewController.h
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 11/13/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "CRNSURLConnectionWithDelegate.h"

@interface CRNetworkViewController : UIViewController <UITableViewDataSource, UITableViewDelegate, NetworkAPIDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tView;



@end
