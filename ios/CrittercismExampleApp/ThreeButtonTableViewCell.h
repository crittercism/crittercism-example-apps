//
//  ThreeButtonTableViewCell.h
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 12/15/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ThreeButtonTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIButton *aButton;
@property (weak, nonatomic) IBOutlet UIButton *bButton;
@property (weak, nonatomic) IBOutlet UIButton *cButton;

@end
